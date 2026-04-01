use crate::application::interfaces::tax_calculator::TaxCalculator;
use crate::domain::entities::tax_result::TaxResult;

pub struct TaxService<T: TaxCalculator> {
    calculator: T,
}

impl<T: TaxCalculator> TaxService<T> {
    pub fn new(calculator: T) -> Self {
        Self { calculator }
    }

    pub fn calculate(&self, gross: f64) -> TaxResult {
        self.calculator.calculate(gross)
    }
}
