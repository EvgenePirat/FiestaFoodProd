const phonePlaceholder = '+38 (___) ___-____';
const phoneMask = phonePlaceholder.split('').map((val) => (val === '_' ? /\d/ : val));

export { phonePlaceholder, phoneMask };
