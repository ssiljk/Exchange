FROM mcr.microsoft.com/mssql/server:2017-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Mypassw0rd*

COPY . /

ENTRYPOINT [ "/bin/bash", "entrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]