export interface ApiResponse<T> {
  success: boolean;
  code: string | null;
  data: T | null;
  message: string | null;
}