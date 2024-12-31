using TempusHive.Modules.Occasions.Domain.Abstractions;
using MediatR;

namespace TempusHive.Modules.Occasions.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
