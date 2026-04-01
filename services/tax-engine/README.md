src/
│
├── domain/
│   ├── entities/
│   │   └── tax_result.rs
│   └── value_objects/
│       └── salary.rs
│
├── application/
│   ├── services/
│   │   └── tax_service.rs
│   └── interfaces/
│       └── tax_calculator.rs
│
├── infrastructure/
│   ├── calculators/
│   │   └── senegal_calculator.rs
│   └── http/
│       └── server.rs
│
├── api/
│   └── handlers/
│       └── tax_handler.rs
│
└── main.rs

mkdir -p src/domain/entities
mkdir -p src/domain/value_objects

mkdir -p src/application/services
mkdir -p src/application/interfaces

mkdir -p src/infrastructure/http
mkdir -p src/infrastructure/calculators

mkdir -p src/api/handlers

src/
│
├── domain/
│   ├── entities/
│   │   └── tax_result.rs
│   └── value_objects/
│       └── salary.rs
│
├── application/
│   ├── services/
│   │   └── tax_service.rs
│   └── interfaces/
│       └── tax_calculator.rs
│
├── infrastructure/
│   ├── calculators/
│   │   └── senegal_calculator.rs
│   └── http/
│       └── server.rs
│
├── api/
│   └── handlers/
│       └── tax_handler.rs
│
└── main.rs