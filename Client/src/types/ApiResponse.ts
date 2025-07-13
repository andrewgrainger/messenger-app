export type APIResponse<T> = {
  response: any;
  success: boolean
  content: T;
  status?: number;
}

export type PaginatedList<T> = {
  data: T;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  pageIndex: number;
  pageSize: number;
  totalCount: number;
};

export type PaginatedAPIResponse<T> = APIResponse<PaginatedList<T>>;
