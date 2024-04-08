import { AxiosInstance } from 'axios';
import { IngredientType } from '../../types/IngredientType.ts';

export default function (instance: AxiosInstance) {
  return {
    getAllIngredient() {
      return instance.get<IngredientType[]>('/api/Ingredient/all');
    },

    postIngredient(payload: Omit<IngredientType, 'id'>) {
      return instance.post<IngredientType>('/api/Ingredient', payload);
    },

    putIngredient(id: IngredientType['id'], payload: IngredientType) {
      return instance.put<IngredientType>(`/api/Ingredient/${id}`, payload);
    },

    deleteIngredient(id: IngredientType['id']) {
      return instance.delete(`/api/Ingredient/${id}`);
    }
  };
}
