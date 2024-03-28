import { Payment } from './enums';
import { OrderItemType } from './OrderItemType';

export type OrderType = {
  id: number;
  date: number;
  list: OrderItemType[];
  finalSum: number;
  payment: Payment;
  entryValue: number;
  restValue: number;
};
