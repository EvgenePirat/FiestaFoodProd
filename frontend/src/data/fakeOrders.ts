import { OrderType } from '../types/OrderType';
import { OrderState, Payment } from '../types/enums';

const orders: OrderType[] = [
  {
    id: 13,
    date: 1711720138804,
    list: [
      {
        id: 1,
        count: 3,
        comment: 'Example'
      },
      {
        id: 4,
        count: 3,
        comment: ''
      },
      {
        id: 5,
        count: 3,
        comment: ''
      },
      {
        id: 6,
        count: 3,
        comment: ''
      },
      {
        id: 7,
        count: 3,
        comment: ''
      },
      {
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    status: OrderState.todo
  },
  {
    id: 15,
    date: 1711720143252,
    list: [
      {
        id: 1,
        count: 3,
        comment: 'Example'
      },
      {
        id: 4,
        count: 3,
        comment: ''
      },
      {
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    status: OrderState.progress
  },
  {
    id: 16,
    date: 1711720150188,
    list: [
      {
        id: 1,
        count: 3,
        comment: 'Example'
      },
      {
        id: 4,
        count: 3,
        comment: ''
      },
      {
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    status: OrderState.todo
  },
  {
    id: 23,
    date: 1711720138804,
    list: [
      {
        id: 1,
        count: 3,
        comment: 'Example'
      },
      {
        id: 4,
        count: 3,
        comment: ''
      },
      {
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    status: OrderState.todo
  },
  {
    id: 25,
    date: 1711720143252,
    list: [
      {
        id: 1,
        count: 3,
        comment: 'Example'
      },
      {
        id: 4,
        count: 3,
        comment: ''
      },
      {
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    status: OrderState.todo
  },
  {
    id: 26,
    date: 1711720150188,
    list: [
      {
        id: 1,
        count: 3,
        comment: 'Example'
      },
      {
        id: 4,
        count: 3,
        comment: ''
      },
      {
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    status: OrderState.progress
  }
];

export { orders };
