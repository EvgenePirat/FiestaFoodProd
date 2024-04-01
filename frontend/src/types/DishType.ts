import { CategoryType } from './CategoryType.ts';

export type DishType = {
  id: number;
  title: string;
  image: string;
  price: number;
  category: CategoryType['id'];
};
