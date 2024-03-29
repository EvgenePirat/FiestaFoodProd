import { AxiosInstance } from 'axios';
import { OrderType } from '../../types/OrderType.ts';

export default function (instance: AxiosInstance) {
  return {
    getAllOrder(pageSize?: number, pageNumber?: number) {
      return console.log('Get all order');
    },

    getOrderById(id: number) {
      return console.log('Get order by id');
    },

    postOrder(payload: Omit<OrderType, 'id' | 'date'>) {
      return console.log('Post order');
    },

    putOrder(payload: OrderType) {
      return console.log('Put order');
    },

    deleteOrder(id: number) {
      return console.log('Delete order id');
    }
  };
}
