import { useMemo } from 'react';

import styles from './Input.module.scss';

export interface InputProps {
  className?: string;
  type?: 'text' | 'tel' | 'password';
  onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void;
  required?: boolean;
  value?: string;
  placeholder?: string;
  innerRef?: React.Ref<HTMLInputElement>;
}

export default function Input({ className, innerRef, ...rest }: InputProps) {
  const classNames = useMemo(() => {
    let str = styles['input'];
    if (className) str += ` ${className}`;
    return str;
  }, [className]);

  return <input className={classNames} ref={innerRef} {...rest} />;
}
