import {useMemo} from 'react';

import styles from './Button.module.scss';

interface ButtonProps {
    className?: string,
    children: React.ReactNode,
    type?: 'button' | 'submit' | 'reset',
    onClick?: () => void
}

export default function Button({className, children, ...rest}: ButtonProps) {
    const classNames = useMemo(() => {
        let str = styles['button'];
        if (className) str += ` ${className}`;
        return str;
    }, [className]);

    return (
        <button className={classNames} {...rest}>
            {children}
        </button>
    );
}
