import { ProductType } from './ProductType';

export type OrderItemType = {
  id: ProductType['id'];
  count: number;
  comment: string;
};
