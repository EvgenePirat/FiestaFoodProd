import { useCallback, useMemo, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../../../redux/store';
import { changeCount, changeComment, removeItem } from '../../../../redux/ordersSlice';

import { OrderItemType } from '../../../../types/OrderItemType';

import { FaMinus, FaPlus, FaTrash } from 'react-icons/fa';

import styles from './OrderItem.module.scss';

interface OrderItemProps {
  item: OrderItemType;
}

export default function OrderItem({ item }: OrderItemProps) {
  const dishes = useSelector((state: RootState) => state.productsSlice.products);
  const dispatch = useDispatch();

  const [posX, setPosX] = useState<number | null>(null);
  const [isVisible, setIsVisible] = useState(false);
  const [value, setValue] = useState(item.comment);

  const dish = useMemo(() => {
    return dishes.find((obj) => obj.id === item.dishId);
  }, [item.dishId, dishes]);

  const onBlurHandler = useCallback(() => {
    dispatch(changeComment({ id: item.dishId, value }));
  }, [dispatch, item.dishId, value]);

  const onTouchStartHandler = useCallback((e: React.TouchEvent<HTMLLIElement>) => {
    setPosX(e.touches[0].clientX);
  }, []);

  const onTouchEndHandler = useCallback(() => {
    setPosX(null);
  }, []);

  const onTouchMoveHandler = useCallback(
    (e: React.TouchEvent<HTMLLIElement>) => {
      if (!posX) return;

      const currentX = e.touches[0].clientX;
      const deltaX = currentX - posX;

      if (Math.abs(deltaX) > 100) {
        setIsVisible(deltaX < 0);
      }
    },
    [posX]
  );

  const removeItemHandler = useCallback(() => {
    dispatch(removeItem(item.dishId));
  }, [dispatch, item.dishId]);

  const changeItemCountHandler = useCallback(
    (value: number) => {
      if (value !== item.count) dispatch(changeCount({ id: item.dishId, value }));
    },
    [dispatch, item.count, item.dishId]
  );

  return (
    <li
      className={styles['item']}
      onTouchStart={onTouchStartHandler}
      onTouchEnd={onTouchEndHandler}
      onTouchMove={onTouchMoveHandler}>
      {dish ? (
        <>
          <div className={styles['info-content']}>
            <span>{dish.title}</span>
            <div className={styles['count-block']}>
              <button
                className={styles['btn']}
                onClick={() => changeItemCountHandler(Math.max(item.count - 1, 1))}>
                <FaMinus />
              </button>
              {item.count}
              <button
                className={styles['btn']}
                onClick={() => changeItemCountHandler(item.count + 1)}>
                <FaPlus />
              </button>
            </div>
            <span>{dish.price}</span>
            <span>{item.count * dish.price}</span>
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
        <p className={styles['not-found']}>Not Found {item.dishId}</p>
      )}
      <button
        className={`${styles['delete-btn']} ${isVisible ? styles['active'] : ''}`}
        onClick={removeItemHandler}>
        <FaTrash />
      </button>
    </li>
  );
}
