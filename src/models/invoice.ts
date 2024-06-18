import type { InvoiceLines } from "./invoice-lines"

export interface Invoice {
    id?: number
    number: number
    amount: number
    date: string
    status: 'paid' | 'pending' | 'new'
    invoiceLines: InvoiceLines[]
}

