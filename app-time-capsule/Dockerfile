FROM node:12.16.2 as build
WORKDIR /app
COPY . .

ENV PUBLIC_URL=/time-capsule/

RUN npm install --silent
RUN npm run build


FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html 
COPY ./nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

