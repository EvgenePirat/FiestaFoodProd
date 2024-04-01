import { DishType } from './DishType.ts';

export type OrderItemType = {
  id: DishType['id'];
  count: number;
  comment: string;
};
