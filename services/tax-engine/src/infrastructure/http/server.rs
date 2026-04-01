use actix_web::{App, HttpServer};

use crate::api::handlers::tax_handler::calculate;

pub async fn run_server() -> std::io::Result<()> {
    HttpServer::new(|| {
        App::new()
            .service(calculate)
    })
    .bind(("127.0.0.1", 8081))?
    .run()
    .await
}