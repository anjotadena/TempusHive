using MediatR;
using TempusHive.Modules.Events.Application.Abstractions.Messaging;
using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Occasions.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
