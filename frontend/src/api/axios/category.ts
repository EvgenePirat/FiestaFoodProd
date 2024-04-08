import { AxiosInstance } from 'axios';
import { CategoryType } from '../../types/CategoryType.ts';

export default function (instance: AxiosInstance) {
  return {
    getAllCategory() {
      return instance.get<CategoryType>('/api/Category/all');
    },

    deleteCategoryById(id: number) {
      return instance.delete(`/api/Category/${id}`);
    },

    postCategory(payload: { Title: CategoryType['title']; FormFile: File }) {
      return instance.post<CategoryType>('/api/Category', payload, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
    },

    putCategory(id: CategoryType['id'], payload: { Title: CategoryType['title']; FormFile: File }) {
      return instance.put<CategoryType>(`/api/Category/${id}`, payload, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
    }
  };
}
