import { AxiosInstance } from 'axios';
import { CategoryType } from '../../types/CategoryType.ts';

export default function (instance: AxiosInstance) {
  return {
    getAllCategory() {
      return console.log('Get all category');
    },

    deleteCategoryById(id: number) {
      return console.log('Delete category by id');
    },

    postCategory(payload: Pick<CategoryType, 'categoryName' | 'photoPaths'>) {
      return console.log('Post category');
    },

    putCategory(payload: CategoryType) {
      return console.log('Put category');
    }
  };
}
