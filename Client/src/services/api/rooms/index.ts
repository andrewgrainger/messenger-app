import axios from "@/plugins/axios"
import { type APIResponse, type PaginatedAPIResponse, type PaginatedList } from "@/types/ApiResponse";
import { type Room } from 'vue-advanced-chat'

export type RoomQueryParams = {
    username: string;
    pageSize?: number;
    pageIndex?: number;
};

export type CreateRoomQueryParams = {
    roomName?: string,
    userNames: string[]
}

const controller = "Room";

const getUserRooms = async (params: RoomQueryParams) => {
    return await axios.get<PaginatedList<Room[]>>(`${controller}/List`, { params });
};

const addRoom = async (newRoom: CreateRoomQueryParams) => {
    return await axios.post<APIResponse<boolean>>(`${controller}/CreateNewRoom`, newRoom);
};

export default {
    getUserRooms,
    addRoom
}