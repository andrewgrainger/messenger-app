import type { APIResponse, PaginatedAPIResponse, PaginatedList } from "@/types/ApiResponse";
import roomController from "./rooms"
import { AxiosError, type AxiosResponse } from "axios";

export const request = <T>(request: Promise<AxiosResponse<T>>): Promise<APIResponse<T>> =>
    request
        .then(({ status, data }) => (
            status === 200
                ? { success: true, content: data }
                : { success: false, content: [] as unknown as T, status }
        ))
        .catch((error: AxiosError<string>) => ({
            success: false,
            status: error.response?.status ?? 400,
            content: [] as unknown as T
        }));

export const paginatedRequest = <T>(request: Promise<AxiosResponse<PaginatedList<T>>>): Promise<PaginatedAPIResponse<T>> =>
    request
        .then(({ status, data }) => ({
            success: status === 200,
            content: {
                data: data.data,
                hasNextPage: data.hasNextPage,
                hasPreviousPage: data.hasPreviousPage,
                pageIndex: data.pageIndex,
                pageSize: data.pageSize,
                totalCount: data.totalCount,
            },
            status
        }))
        .catch((error: AxiosError<string>) => ({
            success: false,
            status: error.response?.status ?? 400,
            content: { data: [] as unknown as T, hasNextPage: false, hasPreviousPage: false, pageIndex: 0, pageSize: 0, totalCount: 0 }
        }));


export const API = {
    room: roomController
}