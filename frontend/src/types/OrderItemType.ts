import { ProductType } from './ProductCardType';

export type OrderItemType = {
  id: ProductType['id'];
  count: number;
  comment: string;
};
