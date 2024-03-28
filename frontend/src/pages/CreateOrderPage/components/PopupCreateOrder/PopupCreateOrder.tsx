import { useCallback, useMemo, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { createOrder } from '../../../../redux/ordersSlice';
import { Button, Popup } from '../../../../components';

import { IoCard, IoCashSharp } from 'react-icons/io5';

import styles from './PopupCreateOrder.module.scss';

enum Payment {
  card = 'card',
  cash = 'cash'
}

const discountArray = [5, 10, 15];
const paymentMethods = [
  {
    icon: IoCard,
    title: 'Безготівковий',
    value: Payment.card
  },
  {
    icon: IoCashSharp,
    title: 'Готівковий',
    value: Payment.cash
  }
];

interface PopupCreateOrderProps {
  onClose?: () => void;
}

export default function PopupCreateOrder({ onClose }: PopupCreateOrderProps) {
  const products = useSelector((state: RootState) => state.productsSlice.products);
  const order = useSelector((state: RootState) => state.ordersSlice.order);
  const dispatch = useDispatch();

  const [discount, setDiscount] = useState(0);
  const [payment, setPayment] = useState<Payment | null>(null);
  const [entryValue, setEntryValue] = useState(0);

  const sum = useMemo(
    () =>
      order.reduce((acc, item) => {
        const product = products.find((obj) => obj.id === item.id);
        return acc + (product?.price ?? 0) * item.count;
      }, 0),
    [order, products]
  );

  const finalSum = useMemo(() => (sum * (100 - discount)) / 100, [discount, sum]);

  const restValue = useMemo(() => entryValue - finalSum, [entryValue, finalSum]);

  const isDisabledBtn = useMemo(
    () => payment === null || (payment === Payment.cash && (entryValue === 0 || restValue < 0)),
    [entryValue, payment, restValue]
  );

  const createOrderHandler = useCallback(() => {
    if (payment) dispatch(createOrder({ finalSum, payment, entryValue, restValue }));
    if (onClose) onClose();
  }, [payment, dispatch, finalSum, entryValue, restValue, onClose]);

  return (
    <Popup onClose={onClose}>
      <div className={styles['content']}>
        <div className={styles['info-block']}>
          <div className={styles['info']}>
            <p className={styles['sum']}>
              Загалом: <span className={styles['value']}>{sum.toFixed(2)} грн</span>
            </p>
            <div className={styles['discount-block']}>
              <span>Знижка:</span>
              {discountArray.map((value) => (
                <button
                  key={value}
                  className={`${styles['discount']} ${value === discount ? styles['active'] : ''}`}
                  onClick={() => setDiscount(value)}>
                  {value}%
                </button>
              ))}
            </div>
          </div>
          <p className={styles['final-sum']}>{finalSum.toFixed(2)} грн</p>
        </div>
        <div className={styles['pays-block']}>
          {paymentMethods.map((obj) => (
            <label className={styles['pay-label']} key={obj.value}>
              <input type="radio" name="payment" onChange={() => setPayment(obj.value)} />
              <span className={styles['pay']}>
                <obj.icon className={styles['icon']} />
                {obj.title}
              </span>
            </label>
          ))}
        </div>
        {payment === Payment.cash && (
          <div className={styles['inputs-block']}>
            <input
              className={styles['input']}
              type="number"
              value={entryValue || ''}
              onChange={(e) => setEntryValue(+e.target.value)}
              placeholder="Внесено"
            />
            <input
              className={styles['input']}
              type="number"
              value={entryValue ? restValue : ''}
              placeholder="Решта"
              readOnly
            />
          </div>
        )}
        <Button
          btnStyle="success"
          className={styles['create-btn']}
          onClick={createOrderHandler}
          disabled={isDisabledBtn}>
          Розраховано
        </Button>
      </div>
    </Popup>
  );
}
