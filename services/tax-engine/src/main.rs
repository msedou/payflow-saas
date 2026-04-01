mod domain;
mod application;
mod infrastructure;
mod api;

use infrastructure::http::server::run_server;

#[actix_web::main]
async fn main() -> std::io::Result<()> {
    println!("🚀 Tax Engine running on http://localhost:8081");
    run_server().await
}
