﻿using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.BLL.Interfaces.BlobStorage;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Resources;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Media.StreetcodeArt.GetByStreetcodeId
{
  public class GetStreetcodeArtByStreetcodeIdHandler : IRequestHandler<GetStreetcodeArtByStreetcodeIdQuery, Result<IEnumerable<StreetcodeArtDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IBlobService _blobService;
        private readonly ILoggerService _logger;

        public GetStreetcodeArtByStreetcodeIdHandler(
            IRepositoryWrapper repositoryWrapper,
            IMapper mapper,
            IBlobService blobService,
            ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _blobService = blobService;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<StreetcodeArtDTO>>> Handle(GetStreetcodeArtByStreetcodeIdQuery request, CancellationToken cancellationToken)
        {
            var art = await _repositoryWrapper
            .StreetcodeArtRepository
            .GetAllAsync(
                predicate: s => s.StreetcodeId == request.StreetcodeId,
                include: art => art
                    .Include(a => a.Art)
                    .Include(i => i.Art.Image) !);

            if (art is null)
            {
                var errorMsg = MessageResourceContext.GetMessage(ErrorMessages.EntityNotFoundWithStreetcode, request, request.StreetcodeId);
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }

            var artsDto = _mapper.Map<IEnumerable<StreetcodeArtDTO>>(art);

            foreach (var artDto in artsDto)
            {
                artDto.Art.Image.Base64 = _blobService.FindFileInStorageAsBase64(artDto.Art.Image.BlobName);
            }

            return Result.Ok(artsDto);
        }
    }
}