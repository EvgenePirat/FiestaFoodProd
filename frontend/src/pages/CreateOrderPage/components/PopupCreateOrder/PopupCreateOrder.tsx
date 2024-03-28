import { useCallback, useMemo, useState } from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
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

  const [discount, setDiscount] = useState(0);
  const [payment, setPayment] = useState<Payment | null>(null);

  const sum = useMemo(
    () =>
      order.reduce((acc, item) => {
        const product = products.find((obj) => obj.id === item.id);
        return acc + (product?.price ?? 0) * item.count;
      }, 0),
    [order, products]
  );

  const finalSum = useMemo(() => (sum * (100 - discount)) / 100, [discount, sum]);

  const createOrderHandler = useCallback(() => {
    console.log('CREATE');
    setDiscount(0);
  }, []);

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
        <div className={styles['pay-block']}>
          <div className={styles['pays']}>
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
        </div>
        <Button btnStyle="success" className={styles['create-btn']} onClick={createOrderHandler}>
          Розраховано
        </Button>
      </div>
    </Popup>
  );
}
