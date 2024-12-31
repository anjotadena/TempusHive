using MediatR;
using TempusHive.Modules.Occasions.Domain.Abstractions;

namespace TempusHive.Modules.Events.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
