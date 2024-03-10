import { useCallback, useMemo, useState } from 'react';
import { products } from '../../../../data/fakeProducts';
import { OrderItemType } from '../../../../types/OrderItemType';

import styles from './OrderItem.module.scss';
import { useDispatch } from 'react-redux';
import { changeComment } from '../../../../redux/ordersSlice';

interface OrderItemProps {
  item: OrderItemType;
}

export default function OrderItem({ item }: OrderItemProps) {
  const dispatch = useDispatch();

  const [isOpen, setIsOpen] = useState(false);
  const [value, setValue] = useState(item.comment);

  const product = useMemo(() => {
    return products.find((obj) => obj.id === item.id);
  }, [item.id]);

  const onBlurHandler = useCallback(() => {
    dispatch(changeComment({ id: item.id, value }));
  }, [dispatch, item.id, value]);

  return (
    <li className={styles['item']} onClick={() => setIsOpen(true)}>
      {product ? (
        <>
          <div className={styles['info-content']}>
            <span>{product.title}</span>
            <span>{item.count}</span>
            <span>{product.price}</span>
            <span>{item.count * product.price}</span>
          </div>
          {isOpen && (
            <div className={styles['comment-block']}>
              <p>Коментар: </p>
              <input
                className={styles['input']}
                value={value}
                onChange={(e) => setValue(e.target.value)}
                onBlur={onBlurHandler}
                type="text"
              />
            </div>
          )}
        </>
      ) : (
        <p className={styles['not-found']}>Not Found {item.id}</p>
      )}
    </li>
  );
}
