import { OrderType } from '../types/OrderType';
import { Payment } from '../types/enums';

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
        id: 2,
        count: 1,
        comment: ''
      }
    ],
    finalSum: 1000,
    payment: Payment.card,
    entryValue: 1200,
    restValue: 200
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
    entryValue: 1200,
    restValue: 200
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
    entryValue: 1200,
    restValue: 200
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
    entryValue: 1200,
    restValue: 200
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
    entryValue: 1200,
    restValue: 200
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
    entryValue: 1200,
    restValue: 200
  }
];

export { orders };
