import { useCallback, useMemo, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { changeComment } from '../../../../redux/ordersSlice';
import { OrderItemType } from '../../../../types/OrderItemType';

import styles from './OrderItem.module.scss';

interface OrderItemProps {
  item: OrderItemType;
}

export default function OrderItem({ item }: OrderItemProps) {
  const products = useSelector((state: RootState) => state.productsSlice.products);
  const dispatch = useDispatch();

  const [value, setValue] = useState(item.comment);

  const product = useMemo(() => {
    return products.find((obj) => obj.id === item.id);
  }, [item.id, products]);

  const onBlurHandler = useCallback(() => {
    dispatch(changeComment({ id: item.id, value }));
  }, [dispatch, item.id, value]);

  return (
    <li className={styles['item']}>
      {product ? (
        <>
          <div className={styles['info-content']}>
            <span>{product.title}</span>
            <span>{item.count}</span>
            <span>{product.price}</span>
            <span>{item.count * product.price}</span>
          </div>
          <input
            className={styles['input']}
            value={value}
            onChange={(e) => setValue(e.target.value)}
            onBlur={onBlurHandler}
            type="text"
            placeholder="Коментар: "
          />
        </>
      ) : (
        <p className={styles['not-found']}>Not Found {item.id}</p>
      )}
    </li>
  );
}
