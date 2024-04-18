import { useCallback, useMemo, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '../../../../redux/store';
import { createOrder } from '../../../../redux/ordersSlice';

import { Payment } from '../../../../types/enums';

import { Button, Popup } from '../../../../components';

import { IoCard, IoCashSharp } from 'react-icons/io5';

import styles from './PopupCreateOrder.module.scss';

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
  const dishes = useSelector((state: RootState) => state.productsSlice.dishes);
  const order = useSelector((state: RootState) => state.ordersSlice.order);
  const dispatch = useDispatch<AppDispatch>();

  const [discount, setDiscount] = useState(0);
  const [paymentType, setPaymentType] = useState<Payment | null>(null);

  const sumDishes = useMemo(
    () =>
      order.reduce((acc, item) => {
        const dish = dishes.find((obj) => obj.id === item.dishId);
        return acc + (dish?.price ?? 0) * item.count;
      }, 0),
    [order, dishes]
  );

  const sum = useMemo(() => (sumDishes * (100 - discount)) / 100, [discount, sumDishes]);

  const createOrderHandler = useCallback(async () => {
    if (paymentType)
      await dispatch(createOrder({ orderItems: order, orderDetail: { sum, paymentType } }));
    if (onClose) onClose();
  }, [paymentType, dispatch, sum, onClose, order]);

  return (
    <Popup onClose={onClose}>
      <div className={styles['content']}>
        <div className={styles['info-block']}>
          <div className={styles['info']}>
            <p className={styles['sum']}>
              Загалом: <span className={styles['value']}>{sumDishes.toFixed(2)} грн</span>
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
          <p className={styles['final-sum']}>{sum.toFixed(2)} грн</p>
        </div>
        <div className={styles['pays-block']}>
          {paymentMethods.map((obj) => (
            <label className={styles['pay-label']} key={obj.value}>
              <input type="radio" name="payment" onChange={() => setPaymentType(obj.value)} />
              <span className={styles['pay']}>
                <obj.icon className={styles['icon']} />
                {obj.title}
              </span>
            </label>
          ))}
        </div>
        <Button
          btnStyle="success"
          className={styles['create-btn']}
          onClick={createOrderHandler}
          disabled={paymentType === null}>
          Розраховано
        </Button>
      </div>
    </Popup>
  );
}
