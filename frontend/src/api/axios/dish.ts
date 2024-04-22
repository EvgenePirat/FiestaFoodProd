import { AxiosInstance } from 'axios';
import { DishType, DishIngredients } from '../../types/DishType.ts';

export default function (instance: AxiosInstance) {
  return {
    getAllDish() {
      return instance.get<DishType[]>('/api/Dish/all');
    },

    getDishById(id: DishType['id']) {
      return instance.get<DishType>(`/api/Dish/${id}`);
    },

    getDishByCategoryId(categoryId: DishType['categoryId']) {
      return instance.get<DishType>(`/api/Dish/category/${categoryId}`);
    },

    postDish(payload: {
      Title: DishType['title'];
      Price: DishType['price'];
      CategoryId: DishType['categoryId'];
      Files: File[];
      DishIngredients: DishType['dishIngredients'];
    }) {
      return instance.post<DishType>('/api/Dish', payload, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
    },

    putDish(
      id: DishType['id'],
      payload: {
        Title: DishType['title'];
        Price: DishType['price'];
        CategoryId: DishType['categoryId'];
        Files: DishType['image'];
        DishIngredients: DishType['dishIngredients'];
      }
    ) {
      return instance.put<DishType>(`/api/Dish/${id}`, payload, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
    },

    deleteDish(id: DishType['id']) {
      return instance.delete(`/api/Dish/${id}`);
    },

    putDishIngredient(id: DishType['id'], payload: DishIngredients[]) {
      return instance.put(`/api/Dish/dishingredient/${id}`, payload);
    }
  };
}
