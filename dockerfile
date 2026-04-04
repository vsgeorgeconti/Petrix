FROM postgres:16-alpine

RUN apk del --no-cache \
    util-linux \
    libintl \
    && rm -rf \
    /usr/share/doc \
    /usr/share/man \
    /usr/share/locale \
    /tmp/* \
    /var/cache/apk/*

ENV PGDATA=/var/lib/postgresql/data/pgdata

EXPOSE 5432