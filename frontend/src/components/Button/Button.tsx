import { useMemo } from 'react';

import styles from './Button.module.scss';

interface ButtonProps {
  className?: string;
  children?: React.ReactNode;
  type?: 'button' | 'submit' | 'reset';
  onClick?: () => void;
  btnStyle?: 'default' | 'success' | 'danger';
}

export default function Button({ btnStyle, className, children, ...rest }: ButtonProps) {
  const classNames = useMemo(() => {
    let str = styles['button'];
    if (btnStyle && btnStyle !== 'default') str += ` ${styles[btnStyle]}`;
    if (className) str += ` ${className}`;
    return str;
  }, [btnStyle, className]);

  return (
    <button className={classNames} {...rest}>
      {children}
    </button>
  );
}
