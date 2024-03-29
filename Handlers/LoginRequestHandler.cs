﻿using CrudApiAssignment.Exceptions;
using CrudApiAssignment.Interfaces;
using CrudApiAssignment.Models;
using CrudApiAssignment.Utilities;
using MediatR;

namespace CrudApiAssignment.Handlers;

public class LoginRequestHandler : IRequestHandler<LoginRequest, ApiResult<string>>
{
    private readonly IIdentityRepository _repository;
    public LoginRequestHandler(IIdentityRepository repository)
    {

        _repository = repository;

    }
    public async Task<ApiResult<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var token = await _repository.GetToken(request.Username, request.Password);
        return ApiResult<string>.Success(token);

    }
}
