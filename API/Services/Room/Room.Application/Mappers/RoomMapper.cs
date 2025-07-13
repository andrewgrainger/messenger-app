using Room.Application.Commands;
using Room.Application.Responses;
using Room.Domain.Entities;
using Room.Domain.Pagination;

namespace Room.Application.Mappers;

public static class RoomMapper
{
    public static Rooms MapToRoomEntity(this CreateRoomCommand command)
    {
        return new Rooms
        {
            RoomName = command.RoomName,
            Users = [.. command.UserNames.Select(userName =>
                new RoomUser
                {
                    UserName = userName,
                    Status = new UserStatus()
                })],
            LastMessage = new LastMessage
            {
                Content = "Room Created",
                SenderId = string.Empty,
                Timestamp = DateTime.UtcNow.ToString()
            }
        };
    }

    public static PaginatedList<Rooms> ToPaginatedList(this IReadOnlyList<Rooms> rooms, int totalRooms, int pageIndex, int pageSize)
    {
        return new PaginatedList<Rooms>(
            pageIndex: pageIndex,
            pageSize: pageSize,
            totalCount: totalRooms,
            data: rooms
        );
    }
}
