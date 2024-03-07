import { useMemo } from 'react';

import styles from './Input.module.scss';

interface InputProps {
  className?: string;
  type?: 'text' | 'password';
  onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void;
  required?: boolean;
  value?: string;
}

export default function Input({ className, ...rest }: InputProps) {
  const classNames = useMemo(() => {
    let str = styles['input'];
    if (className) str += ` ${className}`;
    return str;
  }, [className]);

  return <input className={classNames} {...rest} />;
}
