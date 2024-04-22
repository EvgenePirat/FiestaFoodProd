import { OrderState, Payment } from './enums';
import { OrderItemType } from './OrderItemType';

export type OrderType = {
  id: string;
  number: number;
  orderItems: OrderItemType[];
  orderDetail: { sum: number; paymentType: Payment };
  orderState: OrderState;
  orderCreateDate: string;
  orderFinishedDate: string;
};
