import { useMemo } from 'react';
import { NavLink } from 'react-router-dom';

import styles from './Link.module.scss';

interface LinkProps {
  className?: string;
  children: React.ReactNode;
  to: string;
}

export default function Link({ className, children, to }: LinkProps) {
  const classNames = useMemo(() => {
    let str = styles['link'];
    if (className) str += ` ${className}`;
    return str;
  }, [className]);

  return (
    <NavLink className={classNames} to={to}>
      {children}
    </NavLink>
  );
}
