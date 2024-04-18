import { AxiosInstance } from 'axios';
import { OrderType } from '../../types/OrderType.ts';

type putOrderPayloadType = {
  orderState?: OrderType['orderState'];
  orderFinishedDate?: OrderType['orderFinishedDate'];
  orderItems?: OrderType['orderItems'];
};

export default function (instance: AxiosInstance) {
  return {
    getAllOrder(pageSize?: number, pageNumber?: number) {
      return instance.get<{ orders: OrderType[]; totalPages: number }>('/api/Order/all', {
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

    putOrder(id: OrderType['id'], payload: putOrderPayloadType) {
      return instance.put<OrderType>(`/api/Order/${id}`, payload);
    },

    deleteOrder(id: OrderType['id']) {
      return instance.delete(`/api/Order/${id}`);
    }
  };
}
