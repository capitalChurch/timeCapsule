
const path = '/success';
export const successPath: string = process.env.NODE_ENV === 'development'
    ? path
    : `/time-capsule${path}`;
