FROM node:16.17 AS build-env

# Copy package
COPY package.json yarn.lock ./
# Restore as distinct layers
RUN yarn install

COPY . ./
# Build and publish a release
RUN yarn build

# Build runtime image
FROM nginx:1.22

## Remove default nginx website
RUN rm -rf /usr/share/nginx/html/
COPY nginx/default.conf /etc/nginx/conf.d/
COPY --from=build-env /build /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
