import MaskedInput from 'react-text-mask';

import Input, { InputProps } from '../Input/Input';

interface InputWithMaskProps
  extends Pick<InputProps, 'value' | 'type' | 'onChange' | 'placeholder' | 'required'> {
  mask: (string | RegExp)[];
}

export default function InputWithMask(props: InputWithMaskProps) {
  return (
    <MaskedInput
      {...props}
      render={(ref, props) => (
        <Input innerRef={ref as unknown as InputProps['innerRef']} {...props} />
      )}
    />
  );
}
