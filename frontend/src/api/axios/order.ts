import { AxiosInstance } from 'axios';
import { OrderType } from '../../types/OrderType.ts';

export default function (instance: AxiosInstance) {
  return {
    getAllOrder(pageSize?: number, pageNumber?: number) {
      return instance.get<OrderType[]>('/api/Order/all', {
        params: {
          PageSize: pageSize,
          PageNumber: pageNumber
        }
      });
    },

    getOrderById(id: OrderType['id']) {
      return instance.get<OrderType>(`/api/Order/${id}`);
    },

    postOrder(payload: Pick<OrderType, 'orderDetail' | 'orderItems'>) {
      return instance.post<OrderType>('/api/Order', payload);
    },

    putOrder(
      id: OrderType['id'],
      payload: Pick<OrderType, 'orderState' | 'orderFinishedDate' | 'orderItems'>
    ) {
      return instance.put<OrderType>(`/api/Order/${id}`, payload);
    },

    deleteOrder(id: OrderType['id']) {
      return instance.delete(`/api/Order/${id}`);
    }
  };
}
