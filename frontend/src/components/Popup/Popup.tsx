import { createPortal } from 'react-dom';

import styles from './Popup.module.scss';

interface PopupProps {
  children?: React.ReactNode;
  onClose?: () => void;
}

export default function Popup({ children, onClose }: PopupProps) {
  return createPortal(
    <div className={styles['popup-container']}>
      <div className={styles['overlay']} onClick={onClose}></div>
      <div className={styles['popup']}>{children}</div>
    </div>,
    document.body
  );
}
