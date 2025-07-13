import { type Room } from 'vue-advanced-chat'
import { defineStore } from 'pinia'
import type { APIResponse, PaginatedAPIResponse } from '@/types/ApiResponse'
import { API, paginatedRequest, request } from "@/services/api";
import type { CreateRoomQueryParams, RoomQueryParams } from '@/services/api/rooms';

export interface RoomState {
  rooms: Room[],
  roomsPage: number,
  roomsLoading: boolean,
  roomsLoaded: boolean,
  addNewRoom: boolean,
  addRoomUsername: string,
  addRoomName: string,
  disableForm: boolean,
}

export const useRoomStore = defineStore('room', {
  state: (): RoomState => ({
    rooms: [],
    roomsPage: 0,
    roomsLoading: true,
    roomsLoaded: false,
    addNewRoom: false,
    addRoomUsername: '',
    addRoomName: '',
    disableForm: false
  }),
  actions: {
    async fetchUserRooms(params: RoomQueryParams): Promise<PaginatedAPIResponse<Room[]>> {
      const response = await paginatedRequest(API.room.getUserRooms(params));

      if (!response.success) return response;

      this.rooms = this.roomsPage > 1
        ? this.rooms.concat(response.content.data)
        : response.content.data;

      if (!response.content.hasNextPage) {
        this.roomsLoaded = true;
      }
      
      this.roomsLoading = false;
      this.roomsPage = response.content.pageIndex;

      return response;
    },
    async createRoom(params: CreateRoomQueryParams): Promise<APIResponse<boolean>> {
      this.disableForm = true;

      const response = await request(API.room.addRoom(params));

      if (!response.success) return response.content;

      this.addNewRoom = false;
      this.addRoomUsername = '';
      this.addRoomName = '';
      this.fetchUserRooms({ "username": "string" });

      this.disableForm = false;
      return response.content;
    }
  }
})
