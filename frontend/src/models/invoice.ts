import type { InvoiceLines } from "./invoice-lines"

export interface Invoice {
    id?: number
    number: number
    amount: number
    date: string
    status: 'draft' | 'pending' | 'paid' | 'cancelled'
    invoiceLines: InvoiceLines[]
}

