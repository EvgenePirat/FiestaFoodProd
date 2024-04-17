import { DishType } from './DishType.ts';

export type OrderItemType = {
  dishId: DishType['id'];
  count: number;
  comment: string;
};
