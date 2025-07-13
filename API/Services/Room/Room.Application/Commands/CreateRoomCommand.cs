using MediatR;

namespace Room.Application.Commands;

public record CreateRoomCommand(
    string RoomName,
    List<string> UserNames
) : IRequest<bool>;