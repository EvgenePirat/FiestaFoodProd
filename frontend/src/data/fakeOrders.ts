import { OrderType } from '../types/OrderType';
import { OrderState, Payment } from '../types/enums';

const orders: OrderType[] = [
  {
    id: '13',
    number: 1,
    orderCreateDate: '1711720138804',
    orderFinishedDate: '1711720138804',
    orderItems: [
      {
        dishId: 1,
        count: 3,
        comment: 'Example'
      },
      {
        dishId: 4,
        count: 3,
        comment: ''
      },
      {
        dishId: 5,
        count: 3,
        comment: ''
      },
      {
        dishId: 6,
        count: 3,
        comment: ''
      },
      {
        dishId: 7,
        count: 3,
        comment: ''
      },
      {
        dishId: 2,
        count: 1,
        comment: ''
      }
    ],
    orderDetail: { sum: 1000, paymentType: Payment.card },
    orderState: OrderState.todo
  },
  {
    id: '15',
    number: 2,
    orderCreateDate: '1711720143252',
    orderFinishedDate: '1711720143252',
    orderItems: [
      {
        dishId: 1,
        count: 3,
        comment: 'Example'
      },
      {
        dishId: 4,
        count: 3,
        comment: ''
      },
      {
        dishId: 2,
        count: 1,
        comment: ''
      }
    ],
    orderDetail: { sum: 1000, paymentType: Payment.card },
    orderState: OrderState.progress
  },
  {
    id: '16',
    number: 3,
    orderCreateDate: '1711720150188',
    orderFinishedDate: '1711720150188',
    orderItems: [
      {
        dishId: 1,
        count: 3,
        comment: 'Example'
      },
      {
        dishId: 4,
        count: 3,
        comment: ''
      },
      {
        dishId: 2,
        count: 1,
        comment: ''
      }
    ],
    orderDetail: { sum: 1000, paymentType: Payment.card },
    orderState: OrderState.todo
  },
  {
    id: '23',
    number: 4,
    orderCreateDate: '1711720138804',
    orderFinishedDate: '1711720138804',
    orderItems: [
      {
        dishId: 1,
        count: 3,
        comment: 'Example'
      },
      {
        dishId: 4,
        count: 3,
        comment: ''
      },
      {
        dishId: 2,
        count: 1,
        comment: ''
      }
    ],
    orderDetail: { sum: 1000, paymentType: Payment.card },
    orderState: OrderState.todo
  },
  {
    id: '25',
    number: 5,
    orderCreateDate: '1711720143252',
    orderFinishedDate: '1711720143252',
    orderItems: [
      {
        dishId: 1,
        count: 3,
        comment: 'Example'
      },
      {
        dishId: 4,
        count: 3,
        comment: ''
      },
      {
        dishId: 2,
        count: 1,
        comment: ''
      }
    ],
    orderDetail: { sum: 1000, paymentType: Payment.card },
    orderState: OrderState.todo
  },
  {
    id: '26',
    number: 6,
    orderCreateDate: '1711720150188',
    orderFinishedDate: '1711720150188',
    orderItems: [
      {
        dishId: 1,
        count: 3,
        comment: 'Example'
      },
      {
        dishId: 4,
        count: 3,
        comment: ''
      },
      {
        dishId: 2,
        count: 1,
        comment: ''
      }
    ],
    orderDetail: { sum: 1000, paymentType: Payment.card },
    orderState: OrderState.progress
  }
];

export { orders };
