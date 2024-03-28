import { useCallback } from 'react';
import { useDispatch } from 'react-redux';
import { clearOrder } from '../../../../redux/ordersSlice';
import { Popup } from '../../../../components';

import styles from './PopupSubmitClear.module.scss';

interface PopupSubmitClearProps {
  onClose?: () => void;
}

export default function PopupSubmitClear({ onClose }: PopupSubmitClearProps) {
  const dispatch = useDispatch();

  const submitClear = useCallback(() => {
    dispatch(clearOrder());
    if (onClose) onClose();
  }, [dispatch, onClose]);

  const cancelClear = useCallback(() => {
    if (onClose) onClose();
  }, [onClose]);

  return (
    <Popup onClose={onClose}>
      <div className={styles['content']}>
        <p className={styles['title']}>Очистити замовлення?</p>
        <div className={styles['buttons-block']}>
          <button className={`${styles['btn']} ${styles['submit']}`} onClick={submitClear}>
            Так
          </button>
          <button className={`${styles['btn']} ${styles['cancel']}`} onClick={cancelClear}>
            Ні
          </button>
        </div>
      </div>
    </Popup>
  );
}
