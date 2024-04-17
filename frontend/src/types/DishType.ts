import { CategoryType } from './CategoryType.ts';
import { IngredientType } from './IngredientType.ts';

export type DishIngredients = {
  ingredientId: IngredientType['id'];
  count: number;
};

export type DishType = {
  id: number;
  title: string;
  price: number;
  categoryId: CategoryType['id'];
  image: string;
  dishIngredients: DishIngredients[];
};
